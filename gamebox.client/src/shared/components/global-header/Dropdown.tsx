import { MenuButton } from "../buttons/MenuButton";
import PersonOutlined from '@mui/icons-material/PersonOutlined';
import MailOutlined from '@mui/icons-material/MailOutlined';
import SettingsOutlined from '@mui/icons-material/SettingsOutlined';
import LogoutOutlined from '@mui/icons-material/LogoutOutlined';
import { MenuList } from "@mui/material";

interface DropdownProps {
    opened: boolean;
    onMenuItemClick: (routeValue: string) => void;
}

export const Dropdown = ({ opened, onMenuItemClick }: DropdownProps) => {
    return (opened &&
        <MenuList>
                <MenuButton
                    label={'PROFILE'}
                    icon={<PersonOutlined />}
                    onButtonPress={onMenuItemClick}
                ></MenuButton>
                <MenuButton
                    label={'INBOX'}
                    icon={<MailOutlined />}
                    onButtonPress={onMenuItemClick}
                ></MenuButton>
                <MenuButton
                    label={'SETTINGS'}
                    icon={<SettingsOutlined />}
                    onButtonPress={onMenuItemClick}
                ></MenuButton>
                <MenuButton
                    label={'LOG OUT'}
                    icon={<LogoutOutlined />}
                    onButtonPress={onMenuItemClick}
                ></MenuButton>
        </MenuList>
    )
}