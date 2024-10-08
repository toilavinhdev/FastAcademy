import { Input } from 'antd'
import { UserAvatarComponent } from '~/shared/components'
import { BellOutlined, ShoppingCartOutlined } from '@ant-design/icons'

export default function HomeHeader() {
  return (
    <div className='flex items-center h-full px-16'>
      <Input.Search variant='filled' placeholder='Search for a course' className='w-[400px]' />
      <div className='flex gap-x-6 ml-auto'>
        <ShoppingCartOutlined className='text-[22px] cursor-pointer' />
        <BellOutlined className='text-[22px] cursor-pointer' />
        <UserAvatarComponent />
      </div>
    </div>
  )
}
