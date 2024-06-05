import { Box, InputAdornment, TextField } from '@mui/material';
import SearchIcon from '@mui/icons-material/Search';
import { searchBoxStyles, searchTextFieldStyles } from './Styles';

const SearchBar = () => {
  return (
    <Box sx={searchBoxStyles()}>
      <TextField
        fullWidth
        InputProps={{
          startAdornment: (
            <InputAdornment position="start">
              <SearchIcon />
            </InputAdornment>
          ),
        }}
        sx={(theme) => searchTextFieldStyles(theme)}
      />
    </Box>
  );
};

export default SearchBar;
