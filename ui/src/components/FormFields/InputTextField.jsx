import { TextField } from '@mui/material';

export const inputTextFieldStyles = (theme) => {
  return {
    borderRadius: 1,
    backgroundColor: theme.palette.common.white,
    '& .MuiOutlinedInput-root': {
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
  const { placeholder, field, type } = props;
  return <TextField {...field} type={type} sx={(theme) => inputTextFieldStyles(theme)} placeholder={placeholder} />;
};

export default InputTextField;
