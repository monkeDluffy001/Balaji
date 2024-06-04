import { Controller } from 'react-hook-form';
import getInputComponent from './getInputComponent';

const FormFields = (props) => {
  const { type, name, control, rules } = props;
  const Component = getInputComponent(type);

  return (
    <Controller
      name={name}
      control={control}
      rules={rules}
      render={({ field }) => <Component {...props} field={field} />}
    />
  );
};

export default FormFields;
