import { RightHandLayout } from "../RightHandLayout"
import { SectionHeader } from "../../shared/components/SectionHeader"
import { Divider } from "../../shared/components/Divider"
import { getRecentlyRated, getHighestRated } from "../../shared/api/ratings-api"
import { type Rating } from "../../shared/types/rating";
import { useEffect, useState } from "react"
import { GameWithSingleReview } from "../../shared/components/game-displays/GameWithSingleReview"
import { GameReviewGallery } from "../../shared/components/game-displays/GameReviewGallery"
import styles from "./HomePageLayout.module.scss"

export const HomePageLayout = () => {
    const [recentlyReviewed, setRecentlyReviewed] = useState<Array<Rating>>([]);
    const [singleRecentReviewed, setSingleRecentReviewed] = useState<Rating>();
    const [highestReviewed, setHighestReviewed] = useState<Array<Rating>>([]);
    const [singleHighestReviewed, setSingleHighestReviewed] = useState<Rating>();
    useEffect(() => {
        getRecentlyRated().then((resp) => {
            const singleReview = resp.pop();
            setRecentlyReviewed(resp);
            setSingleRecentReviewed(singleReview);
        });
        getHighestRated().then((resp) => {
            const singleReview = resp.pop();
            setHighestReviewed(resp);
            setSingleHighestReviewed(singleReview);
        })
    }, [])
    return (
        <RightHandLayout
            main={
                <div>
                    <SectionHeader title={'Explore recently rated games'} />
                    <GameWithSingleReview
                        title={singleRecentReviewed?.game.title}
                        avgRating={singleRecentReviewed?.avgRatingWeighted}
                        gameLogoUrl={singleRecentReviewed?.game.imageUrl}
                        review={singleRecentReviewed?.review}
                        username={singleRecentReviewed?.user.username}
                    />
                    <Divider />
                    <GameReviewGallery ratings={recentlyReviewed} />
                    <Divider />
                    <SectionHeader title={'Explore highest rated games'} />
                    <GameWithSingleReview
                        title={singleHighestReviewed?.game.title}
                        avgRating={singleHighestReviewed?.avgRatingWeighted}
                        gameLogoUrl={singleHighestReviewed?.game.imageUrl}
                        review={singleHighestReviewed?.review}
                        username={singleHighestReviewed?.user.username}
                    />
                    <Divider />
                    <GameReviewGallery ratings={highestReviewed} />
                </div>
            }
            side=
            {<div>
                <SectionHeader title={'Played Games'} />

                <SectionHeader title={'Friend Activity'} />
            </div>}
        />
    )

}