import { ReactElement } from "react";
import { IconProps } from "./MenuButton";

interface IconButtonProps {
    value: string,
    onButtonPress: (buttonValue: string) => void;
    icon: ReactElement<IconProps>;
}

export const IconButton = ({ value, onButtonPress, icon }: IconButtonProps) => {
    return (
        <span role="button" onClick={() => onButtonPress(value)}>
            {icon}
        </span>
    )
}