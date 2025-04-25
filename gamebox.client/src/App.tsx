import './App.css';
import { GameboxLayout } from './components/GameboxLayout';
import { HomePageLayout } from './components/HomePage/HomePageLayout';
function App() {
    //const queryClient = makeQueryClient()
    //<GoogleOAuthProvider clientId={'47144089267-gpkju8vdo9lnc6863u2qb1npn6mt458s.apps.googleusercontent.com'}>
    return (
        <GameboxLayout>
            <HomePageLayout/>
        </GameboxLayout>
    );
}

export default App;