import Star from '@mui/icons-material/Star';

interface GameInfoProps {
    gameTitle: string,
    avgRating: number,
    recentReview: string
    recentReviewName: string,
    gameLogoLocation: string
}

export const GameInfoBox = ({ gameTitle, avgRating, recentReview, recentReviewName, gameLogoLocation }: GameInfoProps) => {
    return (
        <div>
            <div>
                <header>
                    <span>{gameTitle}</span>
                    <Star/>{avgRating}
                </header>
                <section>
                    {recentReview}
                    {recentReviewName}

                </section>
            </div>
            <div>
                {gameLogoLocation}
            </div>
        </div>
    )
}