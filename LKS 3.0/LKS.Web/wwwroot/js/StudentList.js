var currentPage = 1, currentSort = 'NumTroop', currentFilter = '', currentFilterCol = '';
$(function () {

    updateStudentsTable();
    });

/** Генерирует разметку для пейджинга
 *@@param {number} count кол-во элементов в таблице
 *@@param {number} maxCount максимальное кол-во элементов на одной странице
 * @@returns {void}
 */
function createPaging(count, maxCount) {
    let html = '<span>';
    for (let i = 1; i <= Math.ceil(count / maxCount); i++) {
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
    updateStudentsTable(currentPage, currentSort, currentFilter);
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
    updateStudentsTable(currentPage, currentSort, currentFilter);
}

/** Обновляем таблицу студентов, применяя текущую сортировку, фильтрацию, страницу
 */
function updateStudentsTable() {
    $.ajax({ // отправляем запрос
        type: 'POST',
        url: '/StudentList/GetStudents',
        data: JSON.stringify({ 'page': currentPage, 'sort': currentSort, 'filter': currentFilter, 'filterCol': currentFilterCol }),
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
                        '<td>' + element.mobilePhonec + '</td>' +
                        '<td>' + element.placeOfResidence + '</td>' +
                        '<td>' + element.placeOfRegestration + '</td>' +
                        '<td>' + element.military + '</td>' +
                        '<td>' + element.familiStatys + '</td>' +
                        '<td>' + element.school + '</td>' +
                        '<td>' + element.two_MobilePhone + '</td>' +
                        '<td>' + element.vuzName + '</td></tr>';
                    row = row.replace(new RegExp('null', 'g'), ''); // удалили все null
                    tbody.append(row);
                    createPaging(data.students.length, 3);
                });
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