import { CompassOutlined, ShoppingCartOutlined } from '@ant-design/icons'
import { Menu } from 'antd'
import { ItemType, MenuItemType } from 'antd/es/menu/interface'
import { useEffect, useState } from 'react'
import { Link, useLocation, useNavigate } from 'react-router-dom'

const logoPath = '../../../../../public/vite.svg'

const items: ItemType<MenuItemType>[] = [
  {
    key: '/',
    icon: <CompassOutlined />,
    label: 'Explore'
  },
  {
    key: '/cart',
    icon: <ShoppingCartOutlined />,
    label: 'Cart'
  }
]

export default function HomeNavbar() {
  const location = useLocation()
  const navigate = useNavigate()
  const [currentPath, setCurrentPath] = useState<string>(
    location.pathname === '/' || location.pathname === '' ? '/' : location.pathname
  )

  useEffect(() => {
    if (location) {
      if (currentPath !== location.pathname) {
        setCurrentPath(location.pathname)
      }
    }
  }, [location, currentPath])

  return (
    <div>
      <Link to={'/'}>
        <img src={logoPath} className='mx-auto my-4 cursor-pointer' />
      </Link>
      <Menu
        onClick={(e) => {
          setCurrentPath(e.key)
        }}
        selectedKeys={[currentPath]}
        defaultSelectedKeys={['1']}
        items={items.map(
          (item) =>
            ({
              ...item,
              onClick: () => {
                navigate(item!.key as string)
              }
            }) as ItemType<MenuItemType>
        )}
        theme='light'
        mode='inline'
        className='border-r'
        style={{
          borderInlineEnd: 0
        }}
      />
    </div>
  )
}
