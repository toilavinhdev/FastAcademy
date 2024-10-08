import { Avatar } from 'antd'

export default function UserAvatarComponent() {
  return (
    <Avatar
      src='https://api.dicebear.com/7.x/miniavs/svg?seed=1'
      size={35}
      className='border border-gray-300 cursor-pointer'
    />
  )
}
