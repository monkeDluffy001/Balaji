import { isNil } from 'lodash';

export const SetItemToLocalStorage = (key, value) => {
  const data = JSON.stringify(value);
  localStorage.setItem(key, data);
};

export const GetItemFromLocalStorage = (key) => {
  const data = localStorage.getItem(key);

  if (isNil(data)) {
    return '';
  } else {
    return JSON.parse(data);
  }
};

export const RemoveItemFromLocalStorage = (key) => {
  localStorage.removeItem(key);
};
