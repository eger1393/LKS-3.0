﻿
export const getArrivalDayValue = val => {
  switch (val) {
    case 'monday':
    case 1:
      return 'Понедельник';
    case 'tuesday':
    case 2:
      return 'Вторник';
    case 'wednesday':
    case 3:
      return 'Среда';
    case 'thursday':
    case 4:
      return 'Четверг';
    case 'friday':
    case 5:
      return 'Пятница';
    case 'saturday':
    case 6:
      return 'Суббота';
    default:
      return '';
  }
}

export const getCoolnessValue = val => {
  switch (val) {
    case 'col':
    case 0:
      return 'Полковник';
    case 'ltCol':
    case 1:
      return 'Подполковник';
    case 'maj':
    case 2:
      return 'Майор';
    case 'capt':
    case 3:
      return 'Капитан';
    default:
      return '';
  }
}

export const getPositionValue = val => {
    switch (val) {
        case 'commander':
        case 0:
            return 'КВ';
        case "firstSquadCommander":
        case 1:
            return 'КО1';
        case "secondSquadCommander":
        case 2:
            return 'КО2';
        case "thirdSquadCommander":
        case 3:
            return 'КО3';
        case "journalist":
        case 4:
            return 'Ж';
        case "secretary":
        case 5:
            return 'С';
        case "none":
        case 6:
            return 'Нет';
        case "deputyCommander":
        case 7:
            return 'ЗКВ';
        case "deputyJournalist":
        case 8:
            return 'ЗЖ';
        case "supplyManager":
        case 9:
            return 'Завхоз';
        default:
            return '';
    }
}

export const getTypeTemplateValue = val => {
  switch (val) {
    case 'singleStudent':
    case 0:
      return 'Один студент';
    case 'manyStudents':
    case 1:
      return 'Список студентов';
    case 'singleTroop':
    case 2:
      return 'Один взвод';
    case 'manyTroops':
    case 3:
      return 'Список взводов';
    default:
      return '';
  }
}