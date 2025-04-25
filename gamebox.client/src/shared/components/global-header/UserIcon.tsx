import userProfileIcon from '../userprofileicon.png'
interface UserIconProps {
    userIconUrl: string,
}

export const UserIcon = ({ userIconUrl }: UserIconProps) => {
    console.log(userIconUrl);
    return (
        <img src={userProfileIcon}></img>
    )
}