import { Layout, theme } from 'antd'
import { Outlet } from 'react-router-dom'
import HomeHeader from './_components/HomeHeader'
import HomeNavbar from './_components/HomeNavbar'

export default function Home() {
  const { token } = theme.useToken()

  return (
    <Layout id='home-container' className='min-h-screen' hasSider>
      <Layout.Sider theme='light' collapsed className='fixed top-0 bottom-0 z-[10] border-r'>
        <HomeNavbar />
      </Layout.Sider>
      <Layout className='pl-[80px]'>
        <Layout.Header
          className='fixed top-0 left-[80px] right-0 z-[10] border-b'
          style={{ padding: 0, background: token.colorBgContainer }}
        >
          <HomeHeader />
        </Layout.Header>
        <Layout.Content className='pt-[64px]'>
          <div className='py-6 px-16'>
            <Outlet />
          </div>
        </Layout.Content>
      </Layout>
    </Layout>
  )
}
