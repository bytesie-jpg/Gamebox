import Menu from '@mui/icons-material/Menu';
import { UserIcon } from './UserIcon';
import { Dropdown } from './Dropdown';
import styles from './UserProfileDropdown.module.scss'
import { useState } from 'react';

interface UserProfileDropdownProps {
    username: string,
    gamesRated: number,
    userIconUrl: string,
}

export const UserProfileDropdown = ({ username, userIconUrl, gamesRated }: UserProfileDropdownProps) => {
    const [opened, setOpened] = useState<boolean>(false);

    return (
        <div className={styles.menuLayout }>
            <div className={styles.profileMenu}>
                <div className={styles.profileInnerMenuContainer}>
                    <Menu onClick={() => setOpened((prev) => {return !prev})} />
                    <span>{username}</span>
                    <span className={styles.icon} ><UserIcon userIconUrl={userIconUrl} /></span>
                </div>
            </div>
            <div className={styles.gamesRated}>{`${gamesRated} GAMES RATED`}</div>
            <Dropdown opened={opened} onMenuItemClick={(value) => console.log(value)}></Dropdown>
        </div>
    )
}