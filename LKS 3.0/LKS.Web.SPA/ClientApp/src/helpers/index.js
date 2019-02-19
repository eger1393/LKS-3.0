
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