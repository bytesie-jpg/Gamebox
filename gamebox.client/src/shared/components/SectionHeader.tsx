import { Divider } from "./Divider"
import styles from "./Sectionheader.module.scss"

interface SectionHeaderProps {
    title: string
}

export const SectionHeader = ({ title }: SectionHeaderProps) => {
    return (
        <div>
            <h2 className={styles.title}>{title.toUpperCase()}</h2>
            <Divider />
        </div>
    )
}