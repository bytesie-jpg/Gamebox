export interface GameDisplayProps {
    avgRating: number;
    title: string;
    gameboxUrl: string;
    reviewComment: ReviewComment;
}

export type ReviewComment = {
    username: string;
    comment: string;
}

export const GameDisplay = ({ avgRating, title, gameboxUrl, reviewComment }: GameDisplayProps) => {
    return (
        <div>
            <div>{avgRating}</div>
            <div>{title}</div>
            <div>{gameboxUrl}</div>
            <div>{reviewComment.comment}</div>
            <div>{reviewComment.username}</div>
        </div>
    )
}