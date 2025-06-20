import type { FC } from 'react'

interface Task {
	id: number
	name: string
	description: string | null
	status: string
}

export const Task: FC<Task> = (task) => {
	return (
		<li key={task.id} className="list-row">
			<div>
				<div>{task.name}</div>
				<div className="text-xs font-semibold uppercase opacity-60">{task.status}</div>
			</div>
			{task.description && <p className="list-col-wrap text-xs">{task.description}</p>}
		</li>
	)
}
