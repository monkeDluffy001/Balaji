import { Controller } from 'react-hook-form';
import getInputComponent from './getInputComponent';

const getValidations = (list) => {
  let rules = {};
  console.log(list);

  return rules;
}

const FormFields = (props) => {
  const { type, name, control, validate } = props;
  const Component = getInputComponent(type);
  const validations = getValidations(validate);

  return (
    <Controller
      name={name}
      control={control}
      rules={validations}
      render={({ field }) => <Component {...props} field={field} />}
    />
  );
};

export default FormFields;
