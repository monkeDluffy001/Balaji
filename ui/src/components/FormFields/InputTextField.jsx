import { TextField } from '@mui/material';
import { isNil } from 'lodash';

export const inputTextFieldStyles = (theme) => {
  return {
    borderRadius: 1,
    '& .MuiOutlinedInput-root': {
      backgroundColor: theme.palette.common.white,
      '& fieldset': {
        borderColor: theme.palette.grey[300], // Initial border color
      },
      '&:hover fieldset': {
        borderColor: theme.palette.grey[300], // Border color on hover
      },
      '&.Mui-focused fieldset': {
        borderColor: theme.palette.grey[400], // Border color on focus
      },
    },
  };
};

const InputTextField = (props) => {
  const { placeholder, field, type, errors } = props;

  return (
    <TextField
      {...field}
      type={type}
      sx={(theme) => inputTextFieldStyles(theme)}
      placeholder={placeholder}
      error={!isNil(errors)}
      helperText={errors && errors.message}
    />
  );
};

export default InputTextField;
