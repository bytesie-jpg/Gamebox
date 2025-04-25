 import { ReactElement } from "react";
import { ListItemIcon, ListItemText, MenuItem } from "@mui/material";

export type IconProps = {
    size: 'small' | 'medium' | 'large',
    color: string
};

interface MenuButtonProps {
    label: string,
    onButtonPress: (buttonValue: string) => void;
    icon: ReactElement<IconProps>;
}

export const MenuButton = ({ label, onButtonPress, icon }: MenuButtonProps) => {
    return (<MenuItem onClick={() => onButtonPress(label)}>
        <ListItemIcon>
            {icon}
        </ListItemIcon>
        <ListItemText>{label}</ListItemText>
    </MenuItem>
    )
}