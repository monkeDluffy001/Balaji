export const loginFormBoxStyles = (theme) => {
  return {
    display: 'flex',
    flexDirection: 'column',
    gap: '15%',
    backgroundColor: theme.palette.common.white,
    padding: 5,
    paddingBottom: 8,
    borderRadius: 1,
  };
};

export const loginPageContainerStyles = () => {
  return {
    display: 'grid',
    gridTemplateColumns: '70% 30%',
  };
};

export const imageContainerStyles = () => {
  return {
    height: '100vh',
  };
};

export const buttonStyles = () => {
  return {
    '&:focus': {
      outline: 'none',
      border: 'none !important',
    },
  };
};
