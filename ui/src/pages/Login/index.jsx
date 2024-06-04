import { Box, Button, Stack, Typography } from '@mui/material';
// import { useDispatch } from 'react-redux';
// import { login } from '../../actions/session';
import { useForm } from 'react-hook-form';
import FormFields from '../../components/FormFields';
import arihant from '../../assets/arihant.png';
import { COMPANY_NAME } from '../../constants/constants';

const loginFormBoxStyles = (theme) => {
  return {
    display: 'flex',
    flexDirection: 'column',
    gap: 12,
    backgroundColor: theme.palette.common.white,
    padding: 5,
    paddingBottom: 8,
    borderRadius: 1,
  };
};

const Login = () => {
  // const dispatch = useDispatch();
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      username: '',
    },
  });
  // const loginData = {
  //   email: 'pratiksamrat14@gmail.com',
  //   password: 'Pratik@14',
  // };

  const onSubmit = (data) => {
    console.log('data = ', data);
  };

  const onCickCreateAccount = () => {
    console.log('singup');
  };
  return (
    <Box
      sx={{
        display: 'grid',
        gridTemplateColumns: '70% 30%',
      }}
    >
      <Box sx={{ height: '100vh' }}>
        <img src={arihant} height={'100%'} width="100%" />
      </Box>
      <Box sx={(theme) => loginFormBoxStyles(theme)}>
        <Typography variant="h5">{COMPANY_NAME}</Typography>

        <Box>
          <Typography variant="h5" textAlign={'center'} gutterBottom>
            Welcome Back !
          </Typography>

          <form onSubmit={handleSubmit(onSubmit)}>
            <Stack gap={2} mt={4}>
              <FormFields
                errors={errors && errors['username']}
                name="username"
                placeholder="Username"
                type="text"
                control={control}
              />
              <FormFields
                errors={errors && errors['password']}
                name="password"
                placeholder="Password"
                type="password"
                control={control}
              />
              <Button type="submit" color="secondary" variant="contained">
                Login
              </Button>
            </Stack>
          </form>
          <Stack direction={'row'} mt={6} gap={1} justifyContent={'center'}>
            <Typography color="GrayText">{"Forget password"}</Typography>
            <Typography sx={{ textDecoration: 'underline', cursor: 'pointer' }} onClick={onCickCreateAccount}>
              Click Here
            </Typography>
          </Stack>
          <Stack direction={'row'} gap={1} mt={2}>
            <Typography color="GrayText">{"Don't have an account? "}</Typography>
            <Typography sx={{ textDecoration: 'underline', cursor: 'pointer' }} onClick={onCickCreateAccount}>
              Create a new account now,
            </Typography>
          </Stack>
        </Box>
      </Box>
    </Box>
  );
};

export default Login;
