import { GoogleLogin } from '@react-oauth/google';

export const GoogleAuth = () => {
    <GoogleLogin
        onSuccess={(credentialResponse) => {
            console.log(credentialResponse);
        }}
        onError={() => {
            console.log('Login Failed');
        }}
    />


}