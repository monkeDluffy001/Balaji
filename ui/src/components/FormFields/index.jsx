import { Controller } from 'react-hook-form';
import getInputComponent from './getInputComponent';

const FormFields = (props) => {
  const { type, name, control } = props;
  const Component = getInputComponent(type);

  return (
    <Controller
      name={name}
      control={control}
      rules={{ required: true }}
      render={({ field }) => <Component {...props} field={field} />}
    />
  );
};

export default FormFields;
