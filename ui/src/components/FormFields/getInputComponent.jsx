import { TextField } from '@mui/material';
import InputTextField from './InputTextField';

export const TYPES = {
  TEXT: 'text',
  EMAIL: 'email',
  PASSWORD: 'password',
};

const getInputComponent = (type) => {
  const { TEXT, EMAIL, PASSWORD } = TYPES;
  switch (type) {
    case TEXT:
    case EMAIL:
    case PASSWORD: {
      return InputTextField;
    }

    default:
      return TextField;
  }
};

export default getInputComponent;
