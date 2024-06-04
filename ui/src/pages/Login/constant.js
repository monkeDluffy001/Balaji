import { IS_VALID_EMAIL, REQUIRED_VALIDATION, STRONG_PASSWORD_VALIDATION } from '../../components/FormFields/constants';

export const LOGIN_FORM_FIELD = [
  {
    name: 'username',
    placeholder: 'Username',
    type: 'text',
    rules: { ...REQUIRED_VALIDATION, ...IS_VALID_EMAIL },
  },
  {
    name: 'password',
    placeholder: 'Password',
    type: 'password',
    rules: { ...REQUIRED_VALIDATION, ...STRONG_PASSWORD_VALIDATION },
  },
];
