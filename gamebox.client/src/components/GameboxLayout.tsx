import styles from './Gamebox.module.scss'


interface ChildrenProps {
    children: React.ReactElement;
}

export const GameboxLayout = ({ children }: ChildrenProps) => {
    return (
        <div className={styles.mainLayout}>
            <div className={styles.left}></div>
            {children}
        </div>
    )
}