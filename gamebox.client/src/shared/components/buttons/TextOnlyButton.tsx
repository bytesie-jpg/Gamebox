import ChevronRight from '@mui/icons-material/ChevronRight';
import styles from './TextOnlyButton.module.scss'
interface TextButtonProps {
    text: string,
    onButtonPress: (e: React.MouseEvent) => void; 
}

export const TextButton = ({ text, onButtonPress }: TextButtonProps) => {
    return (
        <button className={styles.button} role="button" onClick={e => onButtonPress(e)}>
            {text}<ChevronRight/>
        </button>
    )
}