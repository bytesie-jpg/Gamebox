export async function get(url: string): Promise<Response> {
	return await fetch(`https://localhost:7281/${url}`, {
		method: 'GET',
		headers: {
			'content-type': 'application/json;charset=UTF-8',
			'Origin': 'https://localhost:54307'
			},
		})
}

export async function post (url: string, body?: unknown): Promise<Response> {
	return await fetch(url, {
		method: 'POST',
		headers: {
			'content-type': 'application/json;charset=UTF-8',
			'Origin': 'https://localhost:54307'
		},
		body: JSON.stringify({
			body
		}),
	})
}