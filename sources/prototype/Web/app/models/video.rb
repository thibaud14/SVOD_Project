class Video < ActiveRecord::Base
  attr_accessible :bo_url, :country, :duration, :position, :season, :synopsis, :tagline, :thumbnail_url, :title, :type_video, :video_url, :year, :star_rating_avg

  has_and_belongs_to_many :users
  has_and_belongs_to_many :genres
  has_and_belongs_to_many :subtitles
  has_and_belongs_to_many :langues
  belongs_to :collection
  has_many :reviews

  def self.recent(top)
    if top
      find :all, :include => :collection, :order => "created_at DESC", :limit => top
    end
  end

  def self.rated(top)
    if top
      find :all, :include => :collection, :order => "star_rating_avg DESC", :limit => top
    end
  end
end
