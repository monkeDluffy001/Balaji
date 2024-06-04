const CustomImage = (props) => {
  const { imageUrl } = props;
  return <img src={imageUrl} height={'100%'} width="100%" />;
};

export default CustomImage;
