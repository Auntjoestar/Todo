import { apiUrl } from './asp'

export const getActivitiesQuery = async (): Promise<
	[
		{
			id: string
			name: string
			description: string | null
			status: string
		},
	]
> => {
	const url = `${apiUrl}/api/activity`
	const response = await fetch(url, {
		method: 'GET',
		headers: {
			'Content-Type': 'application/json',
		},
		credentials: 'include',
	})

	if (response.status != 200) {
		const errorText = await response.text()
		throw new Error(`Request failed with status: ${response.status} - ${errorText}`)
	}

	const activities = await response.json()

	return activities
}

export const postActivitiesQuery = async (
	name: string,
	description: string | null,
	status: string
): Promise<{ success: boolean }> => {
	const url = `${apiUrl}/api/activity`
	const response = await fetch(url, {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json',
		},
		credentials: 'include',
		body: JSON.stringify({
			name,
			description,
			status,
		}),
	})

	if (response.status != 201) {
		const errorText = await response.text()
		throw new Error(`Request failed with status: ${response.status} - ${errorText}`)
	}

	return { success: true }
}
