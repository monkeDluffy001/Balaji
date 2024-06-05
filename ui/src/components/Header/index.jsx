import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import AdbIcon from '@mui/icons-material/Adb';
import { Stack } from '@mui/material';
import { buttonStyles, navHeaderStyles, navIconStyles } from './Styles';
import SearchBar from '../SearchBar.js';

const pages = ['Dashboard', 'Users', 'Products', 'Contract'];
const settings = ['Profile', 'Logout'];

const Header = () => {
  const [anchorElNav, setAnchorElNav] = React.useState(null);
  const [anchorElUser, setAnchorElUser] = React.useState(null);

  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  console.log(anchorElNav);
  return (
    <AppBar
      sx={() => ({
        // backgroundColor: ,
      })}
      position="static"
      color="secondary"
    >
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <AdbIcon sx={() => navIconStyles()} />
          <Typography variant="h6" noWrap href="#app-bar-with-responsive-menu" sx={() => navHeaderStyles()}>
            ARIHANT
          </Typography>

          <Stack direction="row" flexGrow={1} justifyContent="center" gap={10}>
            {pages.map((page) => (
              <Button size="large" key={page} onClick={handleCloseNavMenu} sx={() => buttonStyles()}>
                <Typography variant="h6">{page}</Typography>
              </Button>
            ))}
          </Stack>

          <SearchBar />

          <Box sx={{ flexGrow: 0, ml: 5 }}>
            <Tooltip title="Open settings">
              <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                <Avatar alt="Remy Sharp" src="/static/images/avatar/2.jpg" />
              </IconButton>
            </Tooltip>
            <Menu
              sx={{ mt: '45px' }}
              id="menu-appbar"
              anchorEl={anchorElUser}
              anchorOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              open={Boolean(anchorElUser)}
              onClose={handleCloseUserMenu}
            >
              {settings.map((setting) => (
                <MenuItem key={setting} onClick={handleCloseUserMenu}>
                  <Typography textAlign="center">{setting}</Typography>
                </MenuItem>
              ))}
            </Menu>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
};
export default Header;
