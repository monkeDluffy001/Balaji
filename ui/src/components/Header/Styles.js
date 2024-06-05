export const navIconStyles = () => {
  return { display: { xs: 'none', md: 'flex' }, mr: 1 };
};

export const navHeaderStyles = () => {
  return {
    mr: 2,
    display: { xs: 'none', md: 'flex' },
    fontFamily: 'monospace',
    fontWeight: 700,
    letterSpacing: '.3rem',
    color: 'inherit',
    textDecoration: 'none',
    cursor: 'pointer',
  };
};

export const buttonStyles = () => {
  return {
    '&:focus': {
      outline: 'none',
      border: 'none !important',
      backgroundColor: 'transparent',
    },
    my: 2,
    color: 'white',
    display: 'block',
  };
};
