import {
  IS_VALID_EMAIL,
  IS_VALID_MOBILE_NUMBER,
  REQUIRED_VALIDATION,
  STRONG_PASSWORD_VALIDATION,
} from '../../components/FormFields/constants';

export const SIGN_UP_FORM_DEFAULT_VALUES = {
  firstName: '',
  lastName: '',
  email: '',
  mobile: '',
  password: '',
  confirmPassword: '',
  address: '',
};

export const SIGN_UP_FORM_FIELD = [
  {
    name: 'firstName',
    placeholder: 'First Name',
    type: 'text',
    rules: { ...REQUIRED_VALIDATION },
  },
  {
    name: 'lastName',
    placeholder: 'Last Name',
    type: 'text',
    rules: { ...REQUIRED_VALIDATION },
  },
  {
    name: 'email',
    placeholder: 'Email address',
    type: 'text',
    rules: { ...REQUIRED_VALIDATION, ...IS_VALID_EMAIL },
  },
  {
    name: 'mobile',
    placeholder: 'Mobile Number',
    type: 'text',
    rules: { ...REQUIRED_VALIDATION, ...IS_VALID_MOBILE_NUMBER },
  },
  {
    name: 'password',
    placeholder: 'Password',
    type: 'password',
    rules: { ...REQUIRED_VALIDATION, ...STRONG_PASSWORD_VALIDATION },
  },
  {
    name: 'confirmPassword',
    placeholder: 'Confirm Password',
    type: 'password',
    rules: { ...REQUIRED_VALIDATION },
  },
  {
    name: 'address',
    placeholder: 'Address',
    type: 'text',
    rules: { ...REQUIRED_VALIDATION },
  },
];
