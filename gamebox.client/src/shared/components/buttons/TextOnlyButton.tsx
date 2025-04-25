import ChevronRight from '@mui/icons-material/ChevronRight';

interface TextButtonProps {
    text: string,
    onButtonPress: (e: React.MouseEvent) => void; 
}

export const TextButton = ({ text, onButtonPress }: TextButtonProps) => {
    return (
        <button role="button" onClick={e => onButtonPress(e)}>
            {text}<ChevronRight/>
        </button>
    )
}