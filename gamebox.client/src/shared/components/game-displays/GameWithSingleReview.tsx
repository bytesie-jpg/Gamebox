import { Star } from "@mui/icons-material";
import defaultImg from "../../../assets/TBDimg.png"
import { TextButton } from "../buttons/TextOnlyButton"
import styles from "./GameWithSingleReview.module.scss"
export interface GameDisplayProps {
    avgRating?: number;
    title?: string;
    gameLogoUrl?: string;
    username?: string;
    review?: string;
}


export const GameWithSingleReview = ({ avgRating, title, gameLogoUrl, review, username }: GameDisplayProps) => {
    const renderImage = () => {
        if (gameLogoUrl == "EMPTY") {
            return (
                <img src={defaultImg}/>
            )
        } else return (<div>No Img</div>)
    }
    return (
        <div className={styles.layout}>
            <div className={styles.imageSide}>{renderImage()}</div>
            <div className={styles.contentSide}>
                <h2 className={styles.title }>{title}</h2>
                <div className={styles.ratingStar}>
                    <Star sx={{ width: 30, height: 30 }} />
                    <span className={styles.ratingText}>{avgRating?.toFixed(2)}</span>
                </div>
                <div className={styles.reviewText}>{review}</div>
                <span>{username}</span>
                <TextButton text={"GO TO GAME"} onButtonPress={() => console.log('clciked')} />
            </div>
        </div>
    )
}