// validations of react hook form
export const REQUIRED_VALIDATION = { required: 'required' };

export const MIN_LENGTH_VALIDATION = (length) => ({
  minLength: {
    value: length,
    message: `at least ${length} characters required`,
  },
});

export const MAX_LENGTH_VALIDATION = (length) => ({
  maxLength: {
    value: length,
    message: `cannot exceed ${length} characters`,
  },
});

export const IS_VALID_EMAIL = {
  pattern: {
    value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i,
    message: 'invalid email address',
  },
};

export const STRONG_PASSWORD_VALIDATION = {
  pattern: {
    value: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?":{}|<>])[A-Za-z\d!@#$%^&*(),.?":{}|<>]{8,}$/,
    message: 'password is weak',
  },
};

export const IS_VALID_MOBILE_NUMBER = {
  pattern: {
    value: /^\d{10}$/,
    message: 'invalid mobile number',
  },
};
