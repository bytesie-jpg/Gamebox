import './App.css';
import { makeQueryClient } from './shared/query-client';
import { QueryClientProvider } from '@tanstack/react-query'

function App() {
    const queryClient = makeQueryClient()
    return (
        <QueryClientProvider client={queryClient}>
        <div>
        </div>
        </QueryClientProvider>
    );
}

export default App;