import { Box, Stack, Typography } from '@mui/material';
import { useForm } from 'react-hook-form';
import FormFields from '../../components/FormFields';
import arihant from '../../assets/arihant.png';
import { COMPANY_NAME } from '../../constants/constants';
import CustomImage from '../../components/CustomImage';
import { LOGIN_FORM_FIELD } from './constant';
import { buttonStyles, imageContainerStyles, loginFormBoxStyles, loginPageContainerStyles } from './Styles';
import { useNavigate } from 'react-router-dom';
import { LoadingButton } from '@mui/lab';
import { useDispatch, useSelector } from 'react-redux';
import { login } from '../../actions/session';

const Login = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const {
    control,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm({
    defaultValues: {
      username: '',
      password: '',
    },
  });

  const loading = useSelector((state) => state.session.loading);
  const user = useSelector((state) => state.session.userData);

  console.log('user = ', user);

  const onSubmit = (data) => {
    const payload = {
      data: {
        password: data.password,
        email: data.username,
      },
      callback: () => {
        reset();
      },
    };

    dispatch(login(payload));
  };

  const onClickCreateAccount = () => {
    navigate('/register');
  };

  return (
    <Box sx={() => loginPageContainerStyles()}>
      <Box sx={() => imageContainerStyles()}>
        <CustomImage imageUrl={arihant} />
      </Box>
      <Box sx={(theme) => loginFormBoxStyles(theme)}>
        <Typography variant="h5">{COMPANY_NAME}</Typography>

        <Box>
          <Typography variant="h5" textAlign="center" gutterBottom>
            Welcome Back ! ✌🏻
          </Typography>

          <form onSubmit={handleSubmit(onSubmit)}>
            <Stack gap={2} mt={4}>
              {LOGIN_FORM_FIELD?.map((item, index) => {
                return <FormFields key={index} {...item} control={control} errors={errors && errors[item?.name]} />;
              })}
              <LoadingButton loading={loading} sx={buttonStyles()} type="submit" color="secondary" variant="contained">
                Login
              </LoadingButton>
            </Stack>
          </form>
          <Stack direction="column">
            <Stack direction="row" mt={6} gap={1} justifyContent="center">
              <Typography color="GrayText">{'Forget password'}</Typography>
              <Typography sx={{ textDecoration: 'underline', cursor: 'pointer' }} onClick={onClickCreateAccount}>
                Click Here
              </Typography>
            </Stack>
            <Stack direction={'row'} gap={1} mt={2}>
              <Typography color="GrayText">{"Don't have an account? "}</Typography>
              <Typography sx={{ textDecoration: 'underline', cursor: 'pointer' }} onClick={onClickCreateAccount}>
                Create a new account now,
              </Typography>
            </Stack>
          </Stack>
        </Box>
      </Box>
    </Box>
  );
};

export default Login;
