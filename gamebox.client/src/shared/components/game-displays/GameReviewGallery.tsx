import { type Rating } from "../../types/rating"
import { CircularQueue } from "../../classes/CirculeQueue"
import { SingleGameRating } from "./SingleGameRating"
import ChevronRight from '@mui/icons-material/ChevronRight';
import ChevronLeft from '@mui/icons-material/ChevronLeft';
import styles from "./GameReviewGallery.module.scss"
import { useState } from "react";
export interface GameReviewGalleryProps {
    ratings: Array<Rating>;
}


export const GameReviewGallery = ({ ratings }: GameReviewGalleryProps) => {
    const galleryQueue: CircularQueue<Rating> = new CircularQueue<Rating>(ratings);
    // first is front, last is back
    const [galleryViewable, setGalleryViewable] = useState<Array<Rating | undefined>>(ratings.slice(ratings.length-4, ratings.length-1));

    return (
        <div className={styles.galleryContainer}>
            <ChevronLeft onClick={() => {
                const item = galleryQueue.dequeueFront();
                const viewableCopy = [...galleryViewable];
                viewableCopy.pop();
                viewableCopy.unshift(item);

                setGalleryViewable(viewableCopy);
            }} />
            {galleryViewable && galleryViewable.map((rating) => {
                return (
                    <SingleGameRating
                        overallRating={rating?.avgRatingWeighted ?? 0}
                        title={rating?.game.title ?? "TBD"}
                        logoUrl={rating?.game.imageUrl?? "EMPTY"}
                    />
                )
            })}
            <ChevronRight onClick={() => {
                const item = galleryQueue.dequeueBack();
                const viewableCopy = [...galleryViewable];
                viewableCopy.shift();
                viewableCopy.push(item);
                setGalleryViewable(viewableCopy);
            }} />
        </div>
    )
}