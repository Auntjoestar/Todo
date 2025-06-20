import type { FC } from 'react'
import { Task } from './Task'

interface Task {
	id: number
	name: string
	description: string | null
	status: string
}

interface TaskListProps {
	tasks: Task[]
}

export const TaskList: FC<TaskListProps> = ({ tasks }) => {
	return (
		<div>
			{tasks.length === 0 ? (
				<div>There are no task at the moment.</div>
			) : (
				<ul className="list bg-base-100 rounded-box border border-gray-600 shadow-md">
					<li className="p-4 pb-2 text-xs tracking-wide opacity-60">Tasks</li>
					{tasks.map((task) => (
						<Task
							id={task.id}
							name={task.name}
							description={task.description}
							status={task.status}
						/>
					))}
				</ul>
			)}
		</div>
	)
}
