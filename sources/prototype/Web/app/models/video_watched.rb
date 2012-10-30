class VideoWatched < ActiveRecord::Base
  # attr_accessible :title, :body

  belongs_to :video
  belongs_to :user

end
