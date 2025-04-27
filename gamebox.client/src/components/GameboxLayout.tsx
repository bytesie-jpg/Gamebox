import { TextButton } from '../shared/components/buttons/TextOnlyButton';
import styles from './Gamebox.module.scss'


interface ChildrenProps {
    children: React.ReactElement;
}

export const GameboxLayout = ({ children }: ChildrenProps) => {
    return (
        <div className={styles.mainLayout}>
            <div className={styles.left}>
                <TextButton text={'Don\'t see a game? Click here!'} onButtonPress={() => console.log("clicked")}/>
            </div>
            {children}
        </div>
    )
}