var currentPage = 1, currentSort = 'NumTroop', currentFilter = '', currentFilterCol = '';
var selectCycle = '#'; //Номер цикла, # - корень(все студенты)
var selectTroop = ''; // если мы в дереве кликнули на взвод, то действие не должно сбрасываться, если мы сортируем по взводу
var pageSize;
$(function () {
    $('#jstree')
        .jstree({
            "plugins": ["sort", "json_data"],
            'core': {
                'themes': {
                    'icons': false
                },
                'strings': {
                    'Loading ...': ' '
                },
                'data': {
                    'url': function (node) {
                        return node.id === '#' ? '/StudentList/GetCycle' : '/StudentList/GetCycle?cycleId=' + node.id;
                    },
                    'data': function (node) {
                        return { 'id': node.id };
                    }
                }
            }
        }).on('changed.jstree', function (e, data) {
            if (data.node.parent == '#') { // клик был по циклу, выбираем цикл, сбрасывам всю сортировку
                selectCycle = data.node.id.replace('cycle-', '');
                selectTroop = '';
                currentPage = 1;
                currentSort = 'NumTroop';
                currentFilter = '';
                currentFilterCol = '';
            } else {
                selectCycle = data.node.parent.replace('cycle-', '');
                selectTroop = data.node.text;
                currentPage = 1;
                currentSort = 'NumTroop';
                currentFilter = '';
                currentFilterCol = '';
            }
            updateStudentsTable();
        })
    pageSize = $('#pageSizeConst').val();
    if (!pageSize) {
        pageSize = 20;
    }
    updateStudentsTable();
    $('.input-container>input').keyup(function (e) {
        if (e.keyCode == 13) {
            setFilter($(this).data('id'));
        }
    });

    // Анимация для лейблов
    $('.input-container>input').focus(function () {
        $(this).parent().addClass("animation");
    });
    $('.input-container>input').blur(function () {
        if (!$(this).val()) {
            $(this).parent().removeClass("animation");
        }
    })
});

/** Генерирует разметку для пейджинга
 *@@param {number} count кол-во элементов в таблице
 *@@param {number} maxCount максимальное кол-во элементов на одной странице
 * @@returns {void}
 */
function createPaging(count) {
    let html = '<span>';
    for (let i = 1; i <= Math.ceil(count / pageSize); i++) {
        html += '<a href="javascript:setPage(' + i + ')">' + i + '</a> ';
    }
    //id = "page' + i + '"
    html += '</span>';
    $('#pagingBox').children().remove();
    $('#pagingBox').append(html);
}

/** Событие происходящее при нажатии на другую страницу
 * @@param {number} numPage номер нажатой страницы
 */
function setPage(numPage) {
    currentPage = numPage;
    updateStudentsTable();
}

/** Событие происходящее при нажатии ссылку для сортрировки
 * @@param {string} sort Параметр для сортировки
 */
function setSort(sort) {
    $('#' + currentSort + 'Row').toggle();

    if (currentSort == sort) {
        currentSort = sort + 'Desc';
    } else {
        currentSort = sort;
    }
    $('#' + currentSort + 'Row').toggle();
    updateStudentsTable();
}

/** Событие происходящее при нажатии на кнопку фильтрации
 * @@param {string} filter Название столбца, к которому применяется фильтрация
 */
function setFilter(filter) {
    if (currentFilterCol != filter) {
        $('#' + currentFilterCol + 'Filter').val(''); // Если предыдущая фильтрация была по другому столбцу очистили предыдущий запрос
    }
    currentFilterCol = filter;
    currentFilter = $('#' + filter + 'Filter').val();
    currentPage = 1; // При применении фильтрации, сбрасываем страницу, оставляем сортировку
    updateStudentsTable();
}

/** Обновляем таблицу студентов, применяя текущую сортировку, фильтрацию, страницу
 */
function updateStudentsTable() {
    $.ajax({ // отправляем запрос
        type: 'POST',
        url: '/StudentList/GetStudents',
        data: JSON.stringify({ 'page': currentPage, 'sort': currentSort, 'filter': currentFilter, 'filterCol': currentFilterCol, 'selectCycle': selectCycle, 'selectTroop': selectTroop }),
        contentType: "application/json",
        dataType: 'json',
        success: function (data) {
            if (data.ok) {
                let tbody = $('table>tbody'); // получили тело таблицы
                tbody.children().remove(); // удалили записи
                data.students.forEach(function (element) {
                    let row = '<tr><td>' + element.middleName + '</td>' +
                        '<td>' + element.firstName + '</td>' +
                        '<td>' + element.lastName + '</td>' +
                        '<td>' + element.numTroop + '</td>' +
                        '<td>' + element.rank + '</td>' +
                        '<td>' + element.specialityName + '</td>' +
                        '<td>' + element.instGroup + '</td>' +
                        '<td>' + element.kurs + '</td>' +
                        '<td>' + element.faculty + '</td>' +
                        '<td>' + element.specInst + '</td>' +
                        '<td>' + element.conditionsOfEducation + '</td>' +
                        '<td>' + element.avarageScore + '</td>' +
                        '<td>' + element.yearOfAddMAI + '</td>' +
                        '<td>' + element.yearOfEndMAI + '</td>' +
                        '<td>' + element.yearOfAddVK + '</td>' +
                        '<td>' + element.yearOfEndVK + '</td>' +
                        '<td>' + element.numberOfOrder + '</td>' +
                        '<td>' + element.dateOfOrder + '</td>' +
                        '<td>' + element.rectal + '</td>' +
                        '<td>' + element.birthday + '</td>' +
                        '<td>' + element.placeBirthday + '</td>' +
                        '<td>' + element.nationality + '</td>' +
                        '<td>' + element.citizenship + '</td>' +
                        '<td>' + element.homePhone + '</td>' +
                        '<td>' + element.mobilePhone + '</td>' +
                        '<td>' + element.placeOfResidence + '</td>' +
                        '<td>' + element.placeOfRegestration + '</td>' +
                        '<td>' + element.military + '</td>' +
                        '<td>' + element.familiStatys + '</td>' +
                        '<td>' + element.school + '</td>' +
                        '<td>' + element.two_MobilePhone + '</td>';
                    row = row.replace(new RegExp('null', 'g'), ''); // удалили все null
                    tbody.append(row);
                });
                createPaging(data.count);
            } else {
                alert("Произошел сбой");
            }
        },
        error: function () {
            alert("Произошел сбой");
        }
    });
    // TODO process event "page click"
}