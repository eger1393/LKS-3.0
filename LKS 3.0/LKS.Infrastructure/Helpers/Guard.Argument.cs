using System;
using System.Linq.Expressions;

// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global

namespace LKS.Infrastructure.Helpers
{
    /// <summary>
    /// Набор вспомогательных методов для уменьшения количества кода путем вынесения часто дублируемых блоков.
    /// Более подробную информацию см. во вложенных классах.
    /// </summary>
    public static partial class Guard
    {
        /// <summary>
        /// Набор статических методов для утверждения над аргументами.
        /// </summary>
        public static class Argument
        {
            #region Methods

            private static void IsNotNullSupressReturn<TArg>(Expression<Func<TArg>> argExpression) where TArg : class =>
                IsNotNull(argExpression);
            private static bool InvertStringIsNullOrEmpty(string value) => !string.IsNullOrEmpty(value);
            private static bool IsNotEmptyString(string argValue) => !(argValue.Equals(string.Empty));

            /// <summary>
            /// Разложение аргумента на его имя и значение по отдельности.
            /// </summary>
            /// <param name="argExpression">Лямбда-выражение для строки X, вида "() => X"</param>
            /// <exception cref="InvalidOperationException"></exception>
            private static (string name, TArg value) ExtractValueFromExpression<TArg>(Expression<Func<TArg>> argExpression)
            {
                switch (argExpression.Body)
                {
                    case MemberExpression memberExpression:
                        return (memberExpression.Member.Name, argExpression.Compile()());
                    case ConstantExpression constExpression:
                        return (constExpression.Type.Name, argExpression.Compile()());
                    default:
                        throw new InvalidOperationException("Expression body must be member expression");
                }
            }

#if DEBUG 
            internal
#else
            private 
#endif
            static Exception ArgumentNullOrEmptyExceptionFactory<TArg>(string argName, TArg argValue) where TArg : class
            {
                switch (argValue)
                {
                    case null:
                        return new ArgumentNullException(argName);
                    case string arg when string.IsNullOrEmpty(arg):
                        return new ArgumentException("Argument value is empty string", argName);
                    default:
                        return new NotSupportedException(argName);
                }
            }
            #endregion


            /// <summary>
            /// Утверждение, что значение аргумента с именем <paramref name="argName" /> не равно <c>null</c> (<c>Nothing</c> в Visual Basic)
            /// </summary>
            /// <param name="argName">Имя аргумента, который необходимо проверить. В большинстве случаев следует использовать <c>nameof()</c></param>
            /// <param name="argValue">Значение аргумента <paramref name="argName" /></param>
            /// <typeparam name="TArg">Тип аргумента <paramref name="argName" /></typeparam>
            /// <exception cref="ArgumentNullException">Исключение, возникающее при ложности утверждения (<paramref name="argValue"/> eq <c>null</c> (<c>Nothing</c> в Visual Basic))</exception>
            public static TArg IsNotNull<TArg>(string argName, TArg argValue) where TArg : class
            {
                if (!(argName is null) && !(argValue is null))
                    return argValue;
                throw ArgumentNullOrEmptyExceptionFactory<TArg>(argName ?? nameof(argName), null);
            }

            /// <summary>
            /// Утверждение, что значение аргумента, переданного при помощи лямбда-выражения <paramref name="argExpression"/>, не равно <c>null</c> (<c>Nothing</c> в Visual Basic)
            /// </summary>
            /// <param name="argExpression">Лямбда-выражение для аргумента вида <c>()=> &lt;arg&gt;</c></param>
            /// <typeparam name="TArg">Тип аргумента для проверки</typeparam>
            /// <exception cref="ArgumentNullException">Исключение, возникающее при ложности утверждения (arg eq <c>null</c> (<c>Nothing</c> в Visual Basic))</exception>
            /// <exception cref="InvalidOperationException">Исключение, возникающее при передаче в <paramref name="argExpression"/> аргумент выражения, отличного от <see cref="MemberExpression"/> или <seealso cref="ConstantExpression"/></exception>
            /// <returns>Значение аргумента, полученное при помощи выражения <paramref name="argExpression"/></returns>
            public static TArg IsNotNull<TArg>(Expression<Func<TArg>> argExpression) where TArg : class
            {
                IsNotNull(nameof(argExpression), argExpression);
                var (argName, argValue) = ExtractValueFromExpression(argExpression);
                IsNotNull(argName, argValue);
                return argValue;
            }



            /// <summary>
            /// Утверждение, что значение каждого из аргументов, переданных при помощи лямбда-выражений <paramref name="argsExpression"/>, не равно <c>null</c> (<c>Nothing</c> в Visual Basic)
            /// </summary>
            /// <param name="argsExpression">Лямбда-выражения для аргумента вида <c>()=> &lt;arg&gt;</c></param>
            /// <exception cref="ArgumentNullException">Исключение, возникающее при ложности утверждения (arg eq <c>null</c> (<c>Nothing</c> в Visual Basic))</exception>
            public static void AreNotNull(params Expression<Func<dynamic>>[] argsExpression) =>
                Array.ForEach(argsExpression, IsNotNullSupressReturn);

            /// <summary>
            /// Выполняет, передаваемое в виде предиката <paramref name="predicate"/>, утверждение над аргументом с именем <paramref name="argName" /> и значением <paramref name="argValue"/>
            /// с указанием фабрики исключения <paramref name="failedExceptionFactory"/>, вызываемой при ложности утверждения.
            /// </summary>
            /// <param name="argName">Имя аргумента (nameof(x))</param>
            /// <param name="argValue">Значение аргумента</param>
            /// <param name="predicate">Делегат, представляющий утверждение над аргументом</param>
            /// <param name="failedExceptionFactory">Делегат, представляющий фабрику исключения, которое должно быть выбюрошено при ложности утверждения</param>
            /// <typeparam name="TArg">Тип аргумента для проверки</typeparam>
            /// <typeparam name="TException">Тип исключения</typeparam>
            public static TArg Check<TArg, TException>(string argName, TArg argValue,
                CheckHandler<TArg> predicate,
                CheckFailedExceptionFactoryHandler<TException, TArg> failedExceptionFactory)
                where TException : Exception
            {
                AreNotNull(
                    () => argName,
                    () => predicate,
                    () => failedExceptionFactory);

                if (!predicate(argValue)) throw failedExceptionFactory(argName, argValue);

                return argValue;
            }


            /// <summary>
            /// Выполняет, передаваемое в виде предиката <paramref name="predicate"/>, утверждение над аргументом, переданным в виде лямбда-выражения с указанием фабрики исключения <paramref name="failedExceptionFactory"/>,
            /// вызываемой при ложности утверждения.
            /// </summary>
            /// <param name="argExpression">Лямбда-выражение для аргумента вида <c>()=> &lt;arg&gt;</c></param>
            /// <param name="predicate">Делегат, представляющий утверждение над аргументом.</param>
            /// <param name="failedExceptionFactory">Делегат, представляющий фабрику исключения, которое должно быть выбюрошено при ложности утверждения.</param>
            /// <typeparam name="TArg">Тип аргумента для проверки</typeparam>
            /// <typeparam name="TException">Тип исключения</typeparam>
            public static TArg Check<TArg, TException>(Expression<Func<TArg>> argExpression,
                CheckHandler<TArg> predicate,
                CheckFailedExceptionFactoryHandler<TException, TArg> failedExceptionFactory) where TException : Exception
            {
                IsNotNull(() => argExpression);
                var (argName, argValue) = ExtractValueFromExpression(argExpression);
                return Check(argName, argValue, predicate, failedExceptionFactory);
            }


            /// <summary>
            /// Выполняет, передаваемое в виде предиката <paramref name="argExpression"/>, утверждение над, извлекаемым из выражения <paramref name="argExpression"/>, аргументом, и, при условии его истинности, присваивает его 
            /// переменной, передаваемой по ссылке (ref) как аргумент <paramref name="assignTo"/>. В противном случае - генерируется исключение при помощи функции фабрики, преставленной аргументом <paramref name="failedExceptionFactory"/>.
            /// Прежде, чем произвести запись, производится проверка на равенство путем вызова <see cref="object.Equals(object,object)"/>.
            /// </summary>
            /// <param name="argExpression">Лямбда-выражение для аргумента вида <c>()=> &lt;arg&gt;</c></param>
            /// <param name="assignTo">Переменная для записи значения</param>
            /// <param name="predicate">Делегат, представляющий утверждение над аргументом</param>
            /// <param name="failedExceptionFactory">Делегат, представляющий фабрику исключения, которое должно быть выбюрошено при ложности утверждения.</param>
            /// <typeparam name="TArg">Тип аргумента для проверки</typeparam>
            /// <typeparam name="TException">Тип исключения</typeparam>
            public static TArg AssignIfPasses<TArg, TException>(Expression<Func<TArg>> argExpression,
                CheckHandler<TArg> predicate,
                CheckFailedExceptionFactoryHandler<TException, TArg> failedExceptionFactory,
                ref TArg assignTo)
                where TException : Exception
            {
                var argValue = Check(argExpression, predicate, failedExceptionFactory);

                if (!Equals(assignTo, argValue))
                    assignTo = argValue;

                return argValue;
            }

            /// <summary>
            /// Выполняет присваивание значения аргумента, переданного при помощи лямбда-выражения <paramref name="argExpression"/>, если утверждение, что оно (значение) отлично от <c>null</c> (<c>Nothing</c> в Visual Basic) - истинно,
            /// переменной, передаваемой по ссылке (ref) как аргумент <paramref name="assignTo"/>. Прежде, чем произвести запись, производится проверка на равенство путем вызова <see cref="object.Equals(object,object)"/>.
            /// В противном случае - генерирует исключение типа <see cref="ArgumentNullException"/>.
            /// </summary>
            /// <param name="argExpression">Лямбда-выражение для аргумента вида <c>()=> &lt;arg&gt;</c></param>
            /// <param name="assignTo">Переменная для записи значения</param>
            /// <typeparam name="TArg">Тип аргумента для проверки</typeparam>
            /// <exception cref="ArgumentNullException">Исключение, возникающее при ложности утверждения (arg eq <c>null</c> (<c>Nothing</c> в Visual Basic))</exception>
            public static TArg AssignIfNotNull<TArg>(Expression<Func<TArg>> argExpression, ref TArg assignTo)
                where TArg : class
                => AssignIfPasses(argExpression, value => !(value is null),
                    (name, value) => new ArgumentNullException(name), ref assignTo);

            /// <summary>
            /// Выполняет присваивание значения аргумента, переданного при помощи лямбда-выражения <paramref name="argExpression"/>, если утверждение, что оно (значение) отлично от <c>null</c> (<c>Nothing</c> в Visual Basic) - истинно,
            /// путем вызова делегата <paramref name="assignAction"/>.
            /// В противном случае - генерирует исключение типа <see cref="ArgumentNullException"/>.
            /// </summary>
            /// <param name="argExpression">Лямбда-выражение для аргумента вида <c>()=> &lt;arg&gt;</c></param>
            /// <param name="assignAction">Делегат, вызываемый при истинности утверждения</param>
            /// <typeparam name="TArg">Тип аргумента для проверки</typeparam>
            /// <exception cref="ArgumentNullException">Исключение, возникающее при ложности утверждения (arg eq <c>null</c> (<c>Nothing</c> в Visual Basic))</exception>
            public static TArg AssignIfNotNull<TArg>(Expression<Func<TArg>> argExpression, Action<TArg> assignAction)
                where TArg : class
            {
                IsNotNull(() => assignAction);
                var argValue = IsNotNull(argExpression);
                assignAction(argValue);
                return argValue;
            }

            /// <summary>
            /// Выполняет, передаваемое в виде предиката <paramref name="argExpression"/>, утверждение над, извлекаемым из выражения <paramref name="argExpression"/>, аргументом, и, при условии его истинности, передает его в качестве агумента делегата <paramref name="assignAction"/>, выполняя его.
            /// В противном случае - генерирует исключение типа <typeparamref name="TException"/>.
            /// </summary>
            /// <param name="argExpression">Лямбда-выражение для аргумента вида <c>()=> &lt;arg&gt;</c></param>
            /// <param name="assignAction">Делегат, который будет выполнен в случае истинности утверждения</param>
            /// <param name="predicate">Делегат, представляющий утверждение над аргументом</param>
            /// <param name="failedExceptionFactory">Делегат, представляющий фабрику исключения, которое должно быть выбюрошено при ложности утверждения.</param>
            /// <typeparam name="TArg">Тип аргумента для проверки</typeparam>
            /// <typeparam name="TException">Тип исключения</typeparam>
            public static TArg AssignIfPasses<TArg, TException>(Expression<Func<TArg>> argExpression,
                Action<TArg> assignAction,
                CheckHandler<TArg> predicate,
                CheckFailedExceptionFactoryHandler<TException, TArg> failedExceptionFactory)
                where TException : Exception
            {
                IsNotNull(() => assignAction);
                var argValue = Check(argExpression, predicate, failedExceptionFactory);
                assignAction(argValue);
                return argValue;
            }

            /// <summary>
            /// Утверждение, что значение строкового аргумента, переданного при помощи выражения <paramref name="argExpression"/>, не является <c>null</c> (<c>Nothing</c> в Visual Basic) и не представлено в виде пустой строки (<see cref="string.Empty"/>).
            /// В случае истинности утверждения выполняется передача значения аргумента в качестве аргумента делегата <paramref name="assignAction"/>. В противном случае - генерируется исключение при помощи фабрики, представленной делегатом <paramref name="failedExceptionFactory"/>.
            /// </summary>
            /// <typeparam name="TException">Тип исключения, генерируемый при помощи фабрики исключений</typeparam>
            /// <param name="argExpression">Лямбда-выражение для аргумента вида <c>()=> &lt;arg&gt;</c></param>
            /// <param name="failedExceptionFactory">Делегат, представляющий фабрику исключения, которое должно быть выбюрошено при ложности утверждения.</param>
            /// <param name="assignAction">Делегат, вызываемый при истинности утверждения</param>
            public static string AssignIfNotNullOrEmptyString<TException>(Expression<Func<string>> argExpression,
                CheckFailedExceptionFactoryHandler<TException, string> failedExceptionFactory,
                Action<string> assignAction)
                where TException : Exception =>
                AssignIfPasses(argExpression, assignAction, InvertStringIsNullOrEmpty, failedExceptionFactory);

            /// <summary>
            /// Утверждение, что значение строкового аргумента, переданного при помощи выражения <paramref name="argExpression"/>, не является <c>null</c> (<c>Nothing</c> в Visual Basic) и не представлено в виде пустой строки (<see cref="string.Empty"/>).
            /// В случае истинности утверждения выполняется передача значения аргумента в качестве аргумента делегата <paramref name="assignAction"/>.
            /// </summary>
            /// <param name="argExpression">Лямбда-выражение для аргумента вида <c>()=> &lt;arg&gt;</c></param>
            /// <param name="assignAction">Делегат, вызываемый при истинности утверждения</param>
            /// <exception cref="ArgumentNullException">Исключение, возникающее при значении <c>null</c> (<c>Nothing</c> в Visual Basic) аргумента</exception>
            /// <exception cref="ArgumentException">Исключение, возникающее при значении <see cref="string.Empty"/> аргумента</exception>
            public static string AssignIfNotNullOrEmptyString(Expression<Func<string>> argExpression,
                Action<string> assignAction) =>
                AssignIfNotNullOrEmptyString(argExpression,
                    ArgumentNullOrEmptyExceptionFactory,
                    assignAction);

            /// <summary>
            /// Утверждение, что значение строкового аргумента, переданного при помощи выражения <paramref name="argExpression"/>, не является <c>null</c> (<c>Nothing</c> в Visual Basic) и не представлено в виде пустой строки (<see cref="string.Empty"/>).
            /// В случае истинности утверждения, выполняется присваивание значения переменной <paramref name="assignTo"/>>, переданной в качестве ref аргумента. В противном случае - генерируется исключение при помощи фабрики, представленной делегатом <paramref name="failedExceptionFactory"/>.
            /// </summary>
            /// <typeparam name="TException">Тип исключения, генерируемый при помощи фабрики исключений</typeparam>
            /// <param name="argExpression">Лямбда-выражение для аргумента вида <c>()=> &lt;arg&gt;</c></param>
            /// <param name="failedExceptionFactory">Делегат, представляющий фабрику исключения, которое должно быть выбюрошено при ложности утверждения.</param>
            /// <param name="assignTo">Переменная для записи значения</param>
            public static string AssignIfNotNullOrEmptyString<TException>(Expression<Func<string>> argExpression,
                CheckFailedExceptionFactoryHandler<TException, string> failedExceptionFactory,
                ref string assignTo)
                where TException : Exception =>
                AssignIfPasses(argExpression, InvertStringIsNullOrEmpty, failedExceptionFactory, ref assignTo);

            /// <summary>
            /// Утверждение, что значение строкового аргумента, переданного при помощи выражения <paramref name="argExpression"/>, не является <c>null</c> (<c>Nothing</c> в Visual Basic) и не представлено в виде пустой строки (<see cref="string.Empty"/>).
            /// В случае истинности утверждения, выполняется присваивание значения переменной <paramref name="assignTo"/>>, переданной в качестве ref аргумента.
            /// </summary>
            /// <param name="argExpression">Лямбда-выражение для аргумента вида <c>()=> &lt;arg&gt;</c></param>
            /// <param name="assignTo">Переменная для записи значения</param>
            /// /// <exception cref="ArgumentNullException">Исключение, возникающее при значении <c>null</c> (<c>Nothing</c> в Visual Basic) аргумента</exception>
            /// <exception cref="ArgumentException">Исключение, возникающее при значении <see cref="string.Empty"/> аргумента</exception>
            public static string AssignIfNotNullOrEmptyString(Expression<Func<string>> argExpression, ref string assignTo) =>
                AssignIfNotNullOrEmptyString(argExpression,
                    ArgumentNullOrEmptyExceptionFactory,
                    ref assignTo);


            #region Nested types
            /// <summary>
            /// Делегат, предоставляющий механизм проверки истинности утверждения над аргументом.
            /// </summary>
            /// <typeparam name="TArg">Тип аргумента.</typeparam>
            /// <param name="argValue">Значение аргумента.</param>
            /// <returns>True, если утверждение истинно, в противном случае - False</returns>
            public delegate bool CheckHandler<in TArg>(TArg argValue);
            /// <summary>
            /// Делегат, предоставляющий механизм создания выбрасываемого исключения при ложности утверждения над аргументом
            /// </summary>
            /// <typeparam name="TException">Тип выбрасываемого исключения</typeparam>
            /// <typeparam name="TArg">Тип значение аргумента</typeparam>
            /// <param name="argName">Имя аргумента</param>
            /// <param name="argValue">Значение аргумента, переданное механизму проверки [истинности] утверждения</param>
            /// <returns></returns>
            public delegate TException CheckFailedExceptionFactoryHandler<out TException, in TArg>(string argName,
                TArg argValue) where TException : Exception;
            #endregion
        }
    }
}
