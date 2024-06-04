import { IconButton, InputAdornment, TextField } from '@mui/material';
import { isNil } from 'lodash';
import VisibilityOutlinedIcon from '@mui/icons-material/VisibilityOutlined';
import { useState } from 'react';
import VisibilityOffOutlinedIcon from '@mui/icons-material/VisibilityOffOutlined';
import { TYPES } from './getInputComponent';

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

export const iconButtonStyles = () => {
  return {
    '&:focus': {
      outline: 'none',
      border: 'none !important',
    },
  };
};

const InputTextField = (props) => {
  const { placeholder, field, type, errors } = props;
  const [show, setShow] = useState(false);

  const onClickShow = () => {
    setShow(!show);
  };
  return (
    <TextField
      {...field}
      type={show ? TYPES.TEXT : type}
      sx={(theme) => inputTextFieldStyles(theme)}
      placeholder={placeholder}
      error={!isNil(errors)}
      helperText={errors && errors.message}
      InputProps={
        type == TYPES.PASSWORD && {
          endAdornment: (
            <InputAdornment position="end">
              <IconButton onClick={onClickShow} sx={() => iconButtonStyles()} edge="end">
                {show ? <VisibilityOffOutlinedIcon /> : <VisibilityOutlinedIcon />}
              </IconButton>
            </InputAdornment>
          ),
        }
      }
    />
  );
};

export default InputTextField;
