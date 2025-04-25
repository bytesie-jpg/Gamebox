interface LayoutProps {
    main: React.ReactElement;
    side: React.ReactElement;
}
import { Header } from '../shared/components/global-header/Header';
import { UserProfileDropdown } from '../shared/components/global-header/UserProfileDropdown';
import styles from './Gamebox.module.scss'

export const RightHandLayout = ({ main, side }: LayoutProps) => {
    return (
        <>
            <div className={styles.middle}>
                <Header />
                {main}
            </div>
            <div className={styles.right}>
                <UserProfileDropdown
                    username={'bytesie'}
                    gamesRated={29}
                    userIconUrl={'url'}
                ></UserProfileDropdown>
                {side}
            </div>
            </>
    )
}