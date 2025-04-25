import { Divider } from "./Divider"

interface SectionHeaderProps {
    title: string
}

export const SectionHeader = ({ title }: SectionHeaderProps) => {
    return (
        <div>
            <h2>{title.toUpperCase()}</h2>
            <Divider />
        </div>
    )
}