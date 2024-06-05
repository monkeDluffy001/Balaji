export const searchTextFieldStyles = (theme) => {
  return {
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

export const searchBoxStyles = () => {
  return {
    width: '300px',
  };
};
