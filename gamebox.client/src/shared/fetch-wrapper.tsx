export const get = async (url: string, body?: any?) => {
    return await fetch(url, {
		method: 'GET',
		headers: {
				'content-type': 'application/json;charset=UTF-8',
			},
		body: JSON.stringify({
				body
			}),
		})
}

export const post = async (url: string, body?: any) => {
	return await fetch(url, {
		method: 'POST',
		headers: {
			'content-type': 'application/json;charset=UTF-8',
		},
		body: JSON.stringify({
			body
		}),
	})
}