# helpful article https://phoenixnap.com/kb/linux-set-environment-variable
# install java (Amazons version)
rpm --import https://yum.corretto.aws/corretto.key
curl -L -o /etc/yum.repos.d/corretto.repo https://yum.corretto.aws/corretto.repo
yum install -y java-17-amazon-corretto-devel.x86_64

# adds a dedicated user for minecraft
sudo adduser minecraft
su

# installs server (should be spigot)
# should also rename from whatever version it is to "server.jar"
# should also install the plugins i've written


# installs server manager


# sets variables
MINECRAFT_SERVER = "Path to minecraft server"
export MINECRAFT_SERVER

# adds service
# minecraft server