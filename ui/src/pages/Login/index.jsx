import { Box, Button, Stack, Typography } from '@mui/material';
// import { useDispatch } from 'react-redux';
// import { login } from '../../actions/session';
import { useForm } from 'react-hook-form';
import FormFields from '../../components/FormFields';

const Login = () => {
  // const dispatch = useDispatch();
  const { control, handleSubmit } = useForm({
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

  return (
    <Box
      sx={(theme) => ({
        display: 'flex',
        flexDirection: 'column',
        gap: 4,
        width: '450px',
        backgroundColor: theme.palette.grey[200],
        padding: 4,
        paddingBottom: 8,
        borderRadius: 1,
      })}
    >
      <Typography>Login</Typography>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Stack gap={2}>
          <FormFields name="username" placeholder="Username" type="text" control={control} />
          <FormFields name="password" placeholder="Password" type="password" control={control} />
          <Button type="submit" variant="contained">
            Login
          </Button>
        </Stack>
      </form>
    </Box>
  );
};

export default Login;
