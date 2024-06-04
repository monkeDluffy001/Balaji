import { Box, Stack, Typography } from '@mui/material';
import CustomImage from '../../components/CustomImage';
import arihant from '../../assets/arihant.png';
import { imageContainerStyles } from '../Login/Styles';
import { LoadingButton } from '@mui/lab';
import { useForm } from 'react-hook-form';
import { SIGN_UP_FORM_DEFAULT_VALUES, SIGN_UP_FORM_FIELD } from './constants';
import FormFields from '../../components/FormFields';
import { useNavigate } from 'react-router-dom';

export const signUpContainerStyles = () => {
  return {
    display: 'grid',
    gridTemplateColumns: '70% 30%',
  };
};

export const signUpFormBoxStyles = () => {
  return {
    padding: 2,
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    width: '100%',
    height: '100vh',
    overflow: 'scroll',
    gap: 1,
  };
};

const SignUp = () => {
  const navigate = useNavigate();
  const {
    control,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm({
    defaultValues: SIGN_UP_FORM_DEFAULT_VALUES,
  });

  const onSubmit = (data) => {
    console.log('data = ', data);
    reset();
  };

  const onClickLoginPage = () => {
    navigate('/');
  };

  return (
    <Box sx={() => signUpContainerStyles()}>
      <Box sx={() => imageContainerStyles()}>
        <CustomImage imageUrl={arihant} />
      </Box>
      <Box sx={() => signUpFormBoxStyles()}>
        <Typography variant="h5">Sign Up</Typography>

        <form onSubmit={handleSubmit(onSubmit)}>
          <Stack gap={2} mt={4} width={'23vw'}>
            {SIGN_UP_FORM_FIELD?.map((item, index) => {
              return <FormFields key={index} {...item} control={control} errors={errors && errors[item?.name]} />;
            })}
            <LoadingButton type="submit" variant="contained" color="secondary" fullWidth>
              Create Account
            </LoadingButton>
          </Stack>
        </form>
        <Stack direction="row" mt={4} gap={1} justifyContent="center">
          <Typography color="GrayText">{'go back to'}</Typography>
          <Typography sx={{ textDecoration: 'underline', cursor: 'pointer' }} onClick={onClickLoginPage}>
            login page
          </Typography>
        </Stack>
      </Box>
    </Box>
  );
};

export default SignUp;
